namespace TutorHubAPI.Models.DTOs
{
    public class AddZakazaniDTO
    {
        public int Id_Oglasa { get; set; }
        public int Id_Profesora { get; set; }
        public string Id_Ucenika { get; set; }
        public string status { get; set; }
        public DateTime datum { get; set; }
        public string vremeOd_Do { get; set; }
    }
}
