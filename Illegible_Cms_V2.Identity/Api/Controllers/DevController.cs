﻿using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Identity.Api.Controllers;

[ApiController]
public class DevController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public DevController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet(Routes.Dev + "hashid/encode/{id}")] // api/dev/hashid/encode/id
                                                 //[Authorize(Permission.DevelopmentAll)]
    public ActionResult GetEncodedId([FromRoute] int id)
    {
        return Ok(id.Encode());
    }

    [HttpGet(Routes.Dev + "hashid/decode/{eid}")] // api/dev/hashid/decode/eid
                                                  //[Authorize(Permission.DevelopmentAll)]
    public ActionResult GetDecodedEid([FromRoute] string eid)
    {
        return Ok(eid.Decode());
    }
}
