using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ejercicio3.Models;
namespace Ejercicio3.Repositorio
{
    public class MaterialesRepositorio
    {
        public List<Materiales> GetMaterial()
        {
            return new List<Materiales>()
            {
                new Materiales()
                {
                    Nombre="Bambu"
                },
                new Materiales()
                {
                    Nombre="Madera"
                },
                new Materiales()
                {
                    Nombre="Ladrillos"
                },
                new Materiales()
                {
                    Nombre="Bloque de hormigón"
                },
                new Materiales()
                {
                    Nombre="Ladrillos triturados"
                },
                new Materiales()
                {
                    Nombre="Tierra de construccion"
                },
                new Materiales()
                {
                    Nombre="Tierra seca y suelta"
                },
                new Materiales()
                {
                    Nombre="Tierra Húmeda y apisonada"
                },
                new Materiales()
                {
                    Nombre="Grava"
                },
                new Materiales()
                {
                    Nombre="Arena seva-Húmeda"
                },
                new Materiales()
                {
                    Nombre="Cemento"
                },
                new Materiales()
                {
                    Nombre="Arsilla seca y compacta"
                },
                new Materiales()
                {
                    Nombre="Hormigón de cemento"
                },
                new Materiales()
                {
                    Nombre="Mortero de cemento"
                },
                new Materiales()
                {
                    Nombre="Hormigon armado(5% de acero)"
                },
            };
        }
    }
}