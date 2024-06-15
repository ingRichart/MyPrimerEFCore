using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUD_Students_POO2.Models; // Asegúrate de que este espacio de nombres sea correcto
using System;
using System.Collections.Generic;
using System.Linq;
using CRUD_Students_POO2.Entities;

namespace CRUD_Students_POO2.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly ILogger<DoctoresController> _logger;
        private readonly ApplicationDbContext _context;

        public DoctoresController(ApplicationDbContext context, ILogger<DoctoresController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult DoctoresAdd()
        {
            return View();
        }

            [HttpPost]
public IActionResult DoctoresAdd(DoctoresModel model)
{
    if (!ModelState.IsValid)
    {
        // Manejar el caso donde el modelo no es válido
        return View(model);
    }

    // Crear el objeto Doctores y asignar los valores del modelo
    Doctores doctores = new Doctores();
    doctores.Id = Guid.NewGuid();
    // Asignar otros campos...

    // Agregar el nuevo doctor al contexto y guardar los cambios en la base de datos
    _context.Doctores.Add(doctores);
    _context.SaveChanges();

    // Redirigir a la acción DoctorList para mostrar la lista actualizada
    return RedirectToAction("DoctorList");
}


        public IActionResult DoctorList()
        {
            //PARA CARGAR INFO = SELECT
            List<DoctoresModel> list = 
            _context.Doctores.Select(d => new DoctoresModel
            
            {
                Id = d.Id,
                Name = d.Name,
                LastName = d.LastName,
                Age = d.Age,
                specialism = d.specialism,
                Tel = d.Tel,
                Cel = d.Cel,
                address = d.address            
            }).ToList();

            _logger.LogInformation("Esto es un mensaje al cargar la información de los doctores");

            return View(list);
            
        }

        public IActionResult DoctoresEdit(Guid id)
        {
            DoctoresModel doctor = _context.Doctores
            .Where(d => d.Id == id).Select(d => new DoctoresModel
            {
                Id = d.Id,
                Name = d.Name,
                LastName = d.LastName,
                Age = d.Age,
                specialism = d.specialism,
                Tel = d.Tel,
                Cel = d.Cel,
                address = d.address
            }).FirstOrDefault();

            return View(doctor);
        }

        [HttpPost]
        public IActionResult DoctoresEdit(DoctoresModel model)
        {
            if (ModelState.IsValid)
            {
                Doctores doctorToUpdate = _context.Doctores.Find(model.Id);
                if (doctorToUpdate != null)
                {
                    doctorToUpdate.Name = model.Name;
                    doctorToUpdate.LastName = model.LastName;
                    doctorToUpdate.Age = model.Age;
                    doctorToUpdate.specialism = model.specialism;
                    doctorToUpdate.Tel = model.Tel;
                    doctorToUpdate.Cel = model.Cel;
                    doctorToUpdate.address = model.address;

                    _context.SaveChanges();
                    _logger.LogInformation("El modelo es válido y se ha actualizado correctamente");
                    return RedirectToAction("DoctorList");
                }
            }

            _logger.LogWarning("El modelo no es valido");
            return View(model);
        }

        public IActionResult DoctoresDeleted(Guid id)
        {
            DoctoresModel doctor = _context.Doctores.Where(d => d.Id == id).Select(d => new DoctoresModel
            {
                Id = d.Id,
                Name = d.Name,
                LastName = d.LastName,
                Age = d.Age,
                specialism = d.specialism,
                Tel = d.Tel,
                Cel = d.Cel,
                address = d.address
            }).FirstOrDefault();

            return View(doctor);
        }

        [HttpPost]
        public IActionResult DoctoresDelete(Guid id)
        {
            Doctores doctorToDelete = _context.Doctores.Find(id);
            if (doctorToDelete != null)
            {
                _context.Doctores.Remove(doctorToDelete);
                _context.SaveChanges();
                _logger.LogInformation("Doctor eliminado correctamente");
            }

            return RedirectToAction("DoctorList");
        }
    }
}