using CQRSNight.CQRSDesignPattern.Commands.CategoryCommands;
using CQRSNight.CQRSDesignPattern.Commands.ProductCommands;
using CQRSNight.CQRSDesignPattern.Handlers.CategoryHandlers;
using CQRSNight.CQRSDesignPattern.Handlers.ProductHandlers;
using CQRSNight.CQRSDesignPattern.Queries.CategoryQueries;
using CQRSNight.CQRSDesignPattern.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSNight.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetProductQueryHandler _getProductQueryHandler;

        public ProductsController(CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductQueryHandler getProductQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getProductQueryHandler = getProductQueryHandler;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _getProductQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("ProductList");
        }
    }
}
