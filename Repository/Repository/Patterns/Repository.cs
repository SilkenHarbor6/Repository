namespace Repository.Patterns
{
    using global::Repository.Model;
    using System;
    using System.Collections.Generic;
    public class Repository : IRepository
    {
        #region Atributos
        private List<Persona> Personas;
        #endregion

        #region Constructor
        public Repository()
        {
            Personas = new List<Persona>();

            //Persona 1
            Persona P1 = new Persona
            {

                nombre = "Francisco",
                apellido="Flores",
                direccion="Mariona",
                edad=60

            };
            //Persona 2
            Persona P2 = new Persona
            {

                nombre = "Mauricio",
                apellido="Funes",
                direccion="Nicaragua",
                edad=55

            };
            //Persona 3
            Persona P3 = new Persona
            {

                nombre = "Salvador",
                apellido="Ceren",
                direccion="Futuramente en Mariona",
                edad=90

            };
            Personas.Add(P1);
            Personas.Add(P2);
            Personas.Add(P3);
        }
        #endregion

        #region MetodosInterfaz
        public bool Delete(Persona item)
        {
            try
            {
                int index = Personas.FindIndex(p => p.nombre.Equals(item.nombre) && 
                                                    p.apellido.Equals(item.apellido) && 
                                                    p.direccion.Equals(item.direccion) && 
                                                    p.edad==item.edad);
                Personas.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Persona> GetAll()
        {
            return Personas;
        }

        public Persona GetByName(String nombre)
        {
            try
            {
                return Personas.Find(p => p.nombre == nombre);
            }
            catch (Exception)
            {
                return default(Persona);
            }
        }

        public bool Save(Persona item)
        {
            try
            {
                Personas.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Persona old, Persona item)
        {
            try
            {
                int index = Personas.FindIndex(p => p.nombre.Equals(old.nombre) &&
                                                    p.apellido.Equals(old.apellido) &&
                                                    p.direccion.Equals(old.direccion) &&
                                                    p.edad == old.edad);
                Personas[index] = item;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

    }
}
