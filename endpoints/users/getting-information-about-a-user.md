---
teaser: See examples on how to get information about a specific user.
---

# Getting information about a user

In the users endpoint, the `GetUser` method can be used to lookup information about specific users. You can request information about a given user either based on their ID or their screen name. For the user ID, this can be done as:

```cshtml
@using Skybrud.Social.Twitter.Responses.Users
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the call to the API
    TwitterGetUserResponse response = Model.Users.GetUser(319219802);

    // Write out some information about the user
    <pre>ID: @response.Body.Id</pre>
    <pre>Screen name: @response.Body.ScreenName</pre>
    <pre>Name: @response.Body.Name</pre>
    <pre>Followers: @response.Body.FollowersCount</pre>
    <pre>Following: @response.Body.FriendsCount</pre>
    <pre>Statuses: @response.Body.StatusesCount</pre>
    
}
```

or for the screen name as:

```cshtml
@using Skybrud.Social.Twitter.Responses.Users
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the call to the API
    TwitterGetUserResponse response = Model.Users.GetUser("abjerner");

    // Write out some information about the user
    <pre>ID: @response.Body.Id</pre>
    <pre>Screen name: @response.Body.ScreenName</pre>
    <pre>Name: @response.Body.Name</pre>
    <pre>Followers: @response.Body.FollowersCount</pre>
    <pre>Following: @response.Body.FriendsCount</pre>
    <pre>Statuses: @response.Body.StatusesCount</pre>
    
}
```

If you instead wish to get information about the authenticated user, but don't already know the user ID or screen name of the user, you can instead use the `VerifyCredentials` method in the accounts endpoint. You can read more about this on the page shown below:



## Related Links

- [Getting information about the authenticated user](../account/getting-information-about-the-authenticated-user.md)