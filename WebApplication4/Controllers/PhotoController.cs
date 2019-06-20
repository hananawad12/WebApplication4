using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeddingGo.Controllers
{
    //[Authorize]
    [Route("api/MakeupArtist/{MakeupArtistId/Photo}")]
    public class PhotoController : ControllerBase
    {
    }
}