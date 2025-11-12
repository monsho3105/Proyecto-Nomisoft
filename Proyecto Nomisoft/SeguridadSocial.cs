namespace Proyecto_Nomisoft
{
    // DTO that represents a row in the `seguridad_social` table
    public class SeguridadSocial
    {
        public int Id { get; set; }
        public string Numero_Documento { get; set; }
        public string Eps { get; set; }
        public string Fondo_Pension { get; set; }
        public string Arl { get; set; }
        public string Caja_Compensacion { get; set; }
        public string Fondo_Cesantias { get; set; }
    }
}