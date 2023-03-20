using lab1.Filters;
using lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace lab1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Car>> GetAll()
    {
        return Car.GetCars(); //Status Code 200
    }
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<Car> GetById(int id)
    {
        var car = Car.GetCars().FirstOrDefault(c => c.Id == id);
        if (car is null)
        {
            return NotFound(new GeneralResponse("Resource is missing"));
        }
        return car;
    }
    [HttpPost]
    [Route("v1")]
    public ActionResult Add(Car car)
    {
        car.Id = new Random().Next(1, 1000); 
        car.Type = "Gas";
        Car.GetCars().Add(car);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = car.Id },
            value: new GeneralResponse("Resource is added"));
    }

    [HttpPost]
    [Route("v2")]
    [ServiceFilter(typeof(ValidateCarTypeAttribute))]
    public ActionResult AddV2(Car car)
    {
        car.Id = new Random().Next(1, 1000); 
        Car.GetCars().Add(car);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = car.Id },
            value: new GeneralResponse("Resource is added"));
    }
    [HttpPut]
    [Route("{id:min(1)}")]
    public ActionResult Edit(Car car, int id)
    {
        if (id != car.Id)
        {
            return BadRequest(new GeneralResponse("Ids don't match"));
        }

        var carToEdit = Car.GetCars()
            .FirstOrDefault(c => c.Id == id);

        if (carToEdit is null)
        {
            return NotFound(new GeneralResponse("Resource is missing"));
        }

        carToEdit.Name = car.Name;
        carToEdit.Model = car.Model;
        carToEdit.Price = car.Price;
        carToEdit.Type=car.Type;
        carToEdit.ProductionDate=car.ProductionDate;

        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        var carToDelete = Car.GetCars()
            .FirstOrDefault(c => c.Id == id);

        if (carToDelete is null)
        {
            return NotFound(new GeneralResponse("Resource is missing"));
        }

        Car.GetCars().Remove(carToDelete);

        return NoContent();
    }

}
