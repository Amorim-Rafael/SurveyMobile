namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public sealed class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }
}
