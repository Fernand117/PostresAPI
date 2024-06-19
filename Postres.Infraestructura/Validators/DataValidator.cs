using Newtonsoft.Json;

namespace Postres.Infraestructura.Validators
{
    public class DataValidator
    {
        public static DataValidator<T> Valid<T>(T data, T command) => new DataValidator<T> { Data = data };
    }

    public class DataValidator<T> : DataValidator
    {
        public T Data { get; set; }
        public T Command { get; set; }

        public T DataValidatorT(T data, T command)
        {
            Data = data;
            Command = command;
            var req = JsonConvert.SerializeObject(data);
            var validator = JsonConvert.DeserializeObject<T>(req);
            return validator!;
        }
    }
}
