using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoEntraID.UI.Controllers;


public class AccountController : Controller
{
    /*
      - In the Authentication section, perform the following actions, and select Configure:
       Redirect URIs text box	Enter https://localhost:5001/
       Front-channel logout URL text box	Enter https://localhost:5001/signout-oidc
       Back in the Platform configurations section, select Add URI, and then enter https://localhost:5001/signin-oidc.
       
       In the Implicit grant and hybrid flows section, select ID tokens (used for implicit and hybrid flows).
     */
    public IActionResult Login(string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, OpenIdConnectDefaults.AuthenticationScheme);
    }

    public IActionResult Logout()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/" },
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme);
    }
}