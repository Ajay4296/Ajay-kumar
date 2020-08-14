namespace BookStoreRepositoryLayer.Common
{
    public class HandelBadRequest
    {
        public string ErrorMessage { get; set; }
    }

    public class JsonErrorModel
    {
        public static object Json()
        {
            var error = new HandelBadRequest
            {
                ErrorMessage = "Controller response failed"
            };
            return error;
        }
    }
}
