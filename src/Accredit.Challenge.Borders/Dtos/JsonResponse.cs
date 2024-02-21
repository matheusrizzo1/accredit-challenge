namespace Accredit.Challenge.Borders.Dtos
{
    public struct JsonResponse
    {
        public bool success { get; set; }
        public object data { get; set; }
        public string msg { get; set; }
    }
}
