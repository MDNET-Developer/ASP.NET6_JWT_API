namespace MD.JWTApp.Back.Core.Application.Dtos
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}
