using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;


namespace CoreApp.Controllers
{
    public class Usuarios : Controller
    {
        private Procs procs;

        public Usuarios()
        {
            procs = new Procs();
        }

        public string Index()
        {
            return "Hola Mundo";
        }

        [HttpGet]
        public JsonResult Info( int? id,
                                string? Nombre,
	                            int? EdadDesde,
	                            int? EdadHasta,
	                            int? Activo,
                                string? FecCreacionDesde,
                                string? FecCreacionHasta,
	                            string? Ordenar)
        {

            string vSQL = "EXEC UsuariosInfo ";
            if (id != null) {vSQL += "@Id=" + id.ToString() + ", ";}
            if (Nombre != null) { vSQL += "@Nombre='" + Nombre + "', "; }
            if (EdadDesde != null) { vSQL += "@EdadDesde=" + EdadDesde.ToString() + ", "; }
            if (EdadHasta != null) { vSQL += "@EdadHasta=" + EdadHasta.ToString() + ", "; }
            if (Activo != null) { vSQL += "@Activo=" + id.ToString() + ", "; }
            if (FecCreacionDesde != null) { vSQL += "@FecCreacionDesde='" + FecCreacionDesde + "', "; }
            if (FecCreacionHasta != null) { vSQL += "@FecCreacionHasta='" + FecCreacionHasta + "', "; }
            if (Ordenar != null) { vSQL += "@Ordenar='" + Ordenar + "', "; }

            if (vSQL != "EXEC UsuariosInfo ")
            {
                vSQL = vSQL.Substring(0, vSQL.Length - 2);
            }

            SqlDataReader dr = procs.EjecutarSQL(vSQL);

            var datatable = new System.Data.DataTable();
            datatable.Load(dr);
            string JsonResponse = string.Empty;
            JsonResponse = JsonConvert.SerializeObject(datatable);

            System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;

            return new JsonResult(JsonResponse, jsonSerializerOptions);

        }

        public JsonResult Gest(int? id,
                                string? Nombre,
                                int? Edad,
                                string? Activo)
        {

            string vSQL = "EXEC UsuariosGest ";
            if (id != null) { vSQL += "@Id=" + id.ToString() + ", "; }
            if (Nombre != null) { vSQL += "@Nombre='" + Nombre + "', "; }
            if (Edad != null) { vSQL += "@Edad=" + Edad.ToString() + ", "; }

            if (Activo=="True" || Activo=="true" || Activo == "1")
            {
                vSQL += "@Activo=1, ";
            } else
            {
                vSQL += "@Activo=0, ";
            }

             

            if (vSQL != "EXEC UsuariosGest ")
            {
                vSQL = vSQL.Substring(0, vSQL.Length - 2);
            }

            SqlDataReader dr = procs.EjecutarSQL(vSQL);

            var datatable = new System.Data.DataTable();
            datatable.Load(dr);
            string JsonResponse = string.Empty;
            JsonResponse = JsonConvert.SerializeObject(datatable);

            System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;

            return new JsonResult(JsonResponse, jsonSerializerOptions);

        }

    }
}
