# Getting information about the authenticated user

In the Twitter API, the `VerifyCredentials` method both lets you verify and get information about the authenticated user. A call to this method can look like:

```cshtml
@using Skybrud.Social.Twitter.Objects.Account
@using Skybrud.Social.Twitter.Options.Account
@using Skybrud.Social.Twitter.Responses.Account
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Initials the options
    TwitterVerifyCrendetialsOptions options = new TwitterVerifyCrendetialsOptions {
        IncludeEmail = true
    };
    
    // Make the request to the API
    TwitterVerifyCredentialsResponse response = Model.Account.VerifyCredentials(options);

    // Get a reference to thr user/account
    TwitterAccount account = response.Body;

    // Write out some information about the account
    <pre>ID: @account.Id</pre>
    <pre>Screen name: @account.ScreenName</pre>
    <pre>Name: @account.Name</pre>
    <pre>Email: @account.Email</pre>
    <pre>Followers: @account.FollowersCount</pre>
    <pre>Following: @account.FriendsCount</pre>
    <pre>Statuses: @account.StatusesCount</pre>
    
}
```



## Getting the email address

Since the email address is a bit more sensitive than the rest of the information retrieved trough the `VerifyCredentials` method, the `Email` property will not be populated by default. 

In order to also retrieve the email address, you should enable the **Request email addresses from users** setting for your Twitter app. You can find a list of your apps at the <a href="https://apps.twitter.com/" target="_blank">Twitter Application Management page</a>.

![image](https://user-images.githubusercontent.com/3634580/28441336-89902f42-6daa-11e7-9220-ec5cf84e8a83.png)