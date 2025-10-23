namespace TP_Final_APIs.Entities;

public class User
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public string Password {  get; set; }
    public string Mail {  get; set; }
    public bool Status { get; set; }
    public string Phone {  get; set; }
    public int IdRestaurant { get; set; }
}
