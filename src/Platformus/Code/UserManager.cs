// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.AspNet.Authentication.Cookies;
using Platformus.Data;
using Platformus.Models;

namespace Platformus
{
  public class UserManager
  {
    private IHandler handler;

    public UserManager(IHandler handler)
    {
      this.handler = handler;
    }

    public User Validate(string loginTypeCode, string identifier, string secret)
    {
      CredentialType credentialType = this.handler.Storage.GetRepository<ICredentialTypeRepository>().WithCode(loginTypeCode);

      if (credentialType == null)
        return null;

      Credential login = this.handler.Storage.GetRepository<ICredentialRepository>().WithCredentialTypeIdAndIdentifierAndSecret(
        credentialType.Id, identifier, MD5Hasher.ComputeHash(secret)
      );

      if (login == null)
        return null;

      return this.handler.Storage.GetRepository<IUserRepository>().WithKey(login.UserId);
    }

    public async void SignIn(User user)
    {
      Claim[] claims = new []
      {
        new Claim(ClaimTypes.Name, string.Format("user{0}", user.Id))
      };

      ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
      ClaimsPrincipal principal = new ClaimsPrincipal(identity);

      await this.handler.Context.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
  }
}