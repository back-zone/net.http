using System;
using Back.Zone.Monads.EitherMonad;
using Back.Zone.Monads.TryMonad;
using Back.Zone.Net.Http.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Back.Zone.Net.Http.Extensions.Monads
{
    public static class Web
    {
        public static IActionResult ToActionResult<TA>(this Try<TA> tryTa) where TA : class
        {
            static IActionResult Failure(Exception e) => new OkObjectResult(WebResponse<Exception>.FailedBecause(e));
            static IActionResult Success(TA value) => new OkObjectResult(WebResponse<TA>.SucceedWith(value));

            return tryTa.Fold(Failure, Success);
        }

        public static IActionResult ToActionResult<TL, TR>(this Either<TL, TR> either) where TL : class where TR : class
        {
            static IActionResult Failure(TL left) => new OkObjectResult(WebResponse<TL>.FailedBecause(left));
            static IActionResult Success(TR right) => new OkObjectResult(WebResponse<TR>.SucceedWith(right));

            return either.Fold(Failure, Success);
        }
    }
}