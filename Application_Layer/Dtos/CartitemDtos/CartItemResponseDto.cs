namespace Application_Layer.Dtos
{
    public class CartItemResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static CartItemResponseDto<T> Ok(T data, string message = "")
        {
            return new CartItemResponseDto<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static CartItemResponseDto<T> Fail(string message)
        {
            return new CartItemResponseDto<T>
            {
                Success = false,
                Message = message,
                Data = default
            };
        }
    }
}
