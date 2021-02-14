using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practica.Server.Data;
using Practica.Shared.Entities;

namespace Pratica.Server.Data
{
    public class Seeder
    {
        // La base de datos.
        private readonly ApplicationDataContext _dataContext;

        // Constructor de la clase.
        public Seeder(ApplicationDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Este metodo permite poblar la base de datos.
        /// </summary>
        public async Task SeedAsync()
        {
            // Verificar que la base de datos exista.
            await _dataContext.Database.EnsureCreatedAsync();

            // Verificar si existen los registros
            await CheckComunasAsync();
            await CheckCiudades();
        }

        public async Task CheckComunasAsync() 
        {
            // Verificar si no existen las comunas.
            if (!_dataContext.Comunas.Any()) 
            {
                // Agregar data.
                // Para Santiago
                _dataContext.Comunas.Add(new Comuna
                {
                    NombreComuna = "Antofagasta",
                    Ciudad = new Ciudad {
                        NombreCiudad = "Antofagasta",
                    }
                });

                _dataContext.Comunas.Add(new Comuna
                {
                    NombreComuna = "Santiago",
                    Ciudad = new Ciudad
                    {
                        NombreCiudad = "Santiago",
                    }
                });

                _dataContext.Comunas.Add(new Comuna
                {
                    NombreComuna = "Calama",
                    Ciudad = new Ciudad
                    {
                        NombreCiudad = "Calama",
                    }
                });

                // Para Antofagasta
                _dataContext.Comunas.Add(new Comuna
                {
                    NombreComuna = "Mejillones",
                    Ciudad = new Ciudad
                    {
                        NombreCiudad = "Antofagasta",
                    }
                });

                _dataContext.Comunas.Add(new Comuna
                {
                    NombreComuna = "Taltal",
                    Ciudad = new Ciudad
                    {
                        NombreCiudad = "Antofagasta",
                    }
                });
            }

            // Guardar cambios.
            await _dataContext.SaveChangesAsync();
        }

        public async Task CheckCiudades()
        {
            if (!_dataContext.Ciudades.Any())
            {
                _dataContext.Ciudades.Add(new Ciudad
                {
                    NombreCiudad = "Calama"
                });

                _dataContext.Ciudades.Add(new Ciudad
                {
                    NombreCiudad = "Antofagasta"
                });
            }

            await _dataContext.SaveChangesAsync();
        }

    }
}
