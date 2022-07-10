using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers;

public class OrganizationController : Controller
{
    // private readonly IUnitOfWork _unitOfWork;
    // private readonly IMapper _mapper;
    // public OrganizationController(IUnitOfWork unitOfWork, IMapper mapper)
    // {
    //     _unitOfWork = unitOfWork;
    //     _mapper = mapper;
    // }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}