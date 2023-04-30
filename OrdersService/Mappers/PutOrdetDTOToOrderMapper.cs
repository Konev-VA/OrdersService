using OrdersService.Models;
using OrdersService.Models.DTO;

namespace OrdersService.Mappers
{
    public class PutOrdetDTOToOrderMapper
    {
        public static Order MapPutOrderDTOToOrder(PutOrderDTO putOrderDTO, Guid guid)
        {
            return new Order()
            {
                Id = guid,
                StatusType = Enum.Parse<StatusType>(putOrderDTO.Status, true),
                Lines = putOrderDTO.Lines
            };
        }
    }
}
