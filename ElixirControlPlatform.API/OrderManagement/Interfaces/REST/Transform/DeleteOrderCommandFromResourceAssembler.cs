using ElixirControlPlatform.API.OrderManagement.Domain.Model.Commands;
namespace ElixirControlPlatform.API.OrderManagement.Interfaces.REST.Transform
{
    public static class DeleteOrderCommandFromResourceAssembler
    {
        public static DeleteOrderCommand ToCommand(int id)
        {
            return new DeleteOrderCommand(id);
        }
    }
}