---
order: 2
---

# Posting a tweet

In the statuses endpoint, the `PostStatusMessage` method lets you post a tweet on behalf of the authenticated user. The method has a couple of overloads, and in it's most simple form, you can post a new tweet like this:

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the call to the API
    TwitterPostStatusMessageResponse response = Model.Statuses.PostStatusMessage("This is a test");

    // Get a reference to the tweet (from the response body)
    TwitterStatusMessage tweet = response.Body;

    // Write out some information about the tweet
    <pre>@tweet.Id</pre>
    <pre>@tweet.Text</pre>
    <pre>@tweet.User.ScreenName</pre>
    <pre>@tweet.RetweetCount</pre>
    
}
```

If the tweet is successfully posted to the API, the method will return an instance of the `TwitterPostStatusMessageResponse` class (as shown in above).



## Replying to a tweet

The example above will just create a new tweet. In order to reply to another tweet, you should specify the ID of that tweet - eg. like:

```csharp
// Make the call to the API
TwitterPostStatusMessageResponse response = Model.Statuses.PostStatusMessage("This is a test", 610040220470349824);
```



## Options

Another overload of the `PostStatusMessage` method allows you to specify some further options. By specifying an instance of the `TwitterPostStatusMessageOptions` class, the example above is similar to calling:

```csharp
// Initialize the options
TwitterPostStatusMessageOptions options = new TwitterPostStatusMessageOptions {
    Status = "This is a test",
    ReplyTo = 610040220470349824
};

// Make the call to the API
TwitterPostStatusMessageResponse response = Model.Statuses.PostStatusMessage(options);
```

To tag the tweet with a specific location, you can fill out a few extra properties like:


```csharp
// Initialize the options
TwitterPostStatusMessageOptions options = new TwitterPostStatusMessageOptions {
    Status = "This is a test",
    ReplyTo = 610040220470349824,
    Latitude = 55.861912,
    Longitude = 9.839534
};

// Make the call to the API
TwitterPostStatusMessageResponse response = Model.Statuses.PostStatusMessage(options);
```