namespace Models.System.DTO
{
    public class EmailSettingsDTO : BaseResponse.BaseResponseDTO
    {
        
        public int ID { get; set; }

        public int LicenseExpiresInXMonths { get; set; }
    }
}
