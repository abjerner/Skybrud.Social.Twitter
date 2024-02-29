---
order: 3
---

# Error Handling

The Twitter API may for whatever reason respond with an error instead of the expected result. If an error is returned, Skybrud.Social will throw an instance of the `TwitterHttpException` exception class with information about the error.

In the example below, I'm attempting to request a tweet with the ID `1`, which doesn't exist. Therefore the Twitter API will respond with a 404 error:

```cshtml
@using Skybrud.Social.Twitter.Exceptions
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    try {


        // Make the call to the Twitter API
        TwitterGetStatusMessageResponse response = Model.Statuses.GetStatusMessage(1);

        // Get a reference to the tweet (from the response body)
        TwitterStatusMessage tweet = response.Body;

        // Write out some information about the tweet
        <pre>@tweet.Text</pre>
        <pre>@tweet.User.ScreenName</pre>
        <pre>@tweet.RetweetCount</pre>

    } catch (TwitterHttpException ex) {

        <pre>@ex.Response.StatusCode</pre>
        <pre>@ex.Code</pre>
        <pre>@ex.Message</pre>
        <pre>@ex.Response.Body</pre>

    } catch (Exception) {

        <pre>Just to be safe.</pre>

    }

}
```

The `TwitterHttpException` class only represents errors returned by the API. Just to be safe, it's also a good idea to handle any other exceptions throw by the `GetStatusMessage` method or underlying logic.

For instance, if Twitter changes something in their API, and Skybrud.Social doesn't understand how to parse the change, the extra `catch` clause may help your code from breaking.