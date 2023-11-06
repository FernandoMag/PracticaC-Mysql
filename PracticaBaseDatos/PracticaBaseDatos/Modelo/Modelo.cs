using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBaseDatos.Modelo
{
    internal class Modelo
    {
        int matricula;      
        string nombre;
        string apellido;
        string sexo;
        int claveEmpresa;
        string empresa;

        public int Matricula { get => matricula; set => matricula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public int ClaveEmpresa { get => claveEmpresa; set => claveEmpresa = value; }
        public string Empresa { get => empresa; set => empresa = value; }
    }
}
