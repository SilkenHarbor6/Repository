namespace Repository.Patterns
{
    using global::Repository.Model;
    using System;
    using System.Collections.Generic;
    public interface IRepository
    {
        #region Metodos

        List<Persona> GetAll();//Obtener todas las personas
        Persona GetByName(String nombre); //Obtener un solo registro por id
        bool Delete(Persona item); //Metodo que eliminara a una registro
        bool Save(Persona item);//Metodo para guardar un registro nuevo
        bool Update(Persona old,Persona item);//Metodo para actualizar un registro



        #endregion
    }
}
