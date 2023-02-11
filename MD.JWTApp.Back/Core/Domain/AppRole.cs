namespace MD.JWTApp.Back.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public string? Definiton { get; set; }
        public List<AppUser> AppUsers { get; set; }

        //Biz ona gore burada constructordan istifade etdik ki, hec bir data olmasa null qaytarmasin,  bos obyekt kecsin  c# urekdir , java boyrekdir.
        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
    }
}

