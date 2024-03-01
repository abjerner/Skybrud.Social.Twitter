# Setting up an authentication page

The <code type="Skybrud.Social.Twitter.OAuth.TwitterOAuthClient, Skybrud.Social.Twitter">TwitterOAuthClient</code> class handles the necessary logic for authenticating with the Twitter API.

In order to get started, you need to create a [Twitter app](https://apps.twitter.com/) (or use an existing app if you already have one). Your Twitter app will have a consumer key and consumer secret, which together identifies your app.

With the Twitter app in place, you can initialize a new instance of the <code type="Skybrud.Social.Twitter.OAuth.TwitterOAuthClient, Skybrud.Social.Twitter">TwitterOAuthClient</code> class like this:

```csharp
// Initialize the OAuth client
TwitterOAuthClient oauth = new TwitterOAuthClient {
    ConsumerKey = "Your consumer key",
    ConsumerSecret = "Your consumer secret",
    Callback = "http://social.abjerner/twitter/oauth/"
};
```

The `Callback` property represents the URL of your authentication page. When the authentication is completed through Twitter's authentication dialog, the user is redirected back to this URL.



## Obtaining a request token

Twitter uses OAuth 1.0a for authentication, where the first part is to obtain a request token. This is a server to server call which helps identify your app and the user to Twitter.

```csharp
// Make the request to the Twitter API to get a request token
SocialOAuthRequestTokenResponse response = oauth.GetRequestToken();

// Get the request token from the response body
SocialOAuthRequestToken requestToken = oauth.GetRequestToken().Body;
```

The response holds both a request token and a request token secret, which is then used for hashing and signing the next request of the authentication.

After we have received the request token and request token secret, we need to redirect the user to the Twitter authentication dialog. But since the request token and request token secret helps to identify the user, we must first store this in a session (or similar) on the server, so we can retrieve it once the user is redirected back to the URL as defined by the `Callback` property.

```csharp
// Save the token information to the session so we can grab it later
Session[requestToken.Token] = requestToken;

// Redirect the user to the authentication page at Twitter.com
Response.Redirect(requestToken.AuthorizeUrl);
```



## Obtaining an access token

Once the user grants your app access to the user's Twitter account, the user is redirected back to the URL as defined by the `Callback` property, but with the `oauth_token` and `oauth_verifier` parameters in the query string.

`oauth_token` is the request token that we received earlier. With this, we can retrieve the request token secret from the session. We should use these to update the `Token` and `TokenSecret` properties of the <code type="Skybrud.Social.Twitter.OAuth.TwitterOAuthClient, Skybrud.Social.Twitter">TwitterOAuthClient</code> instance.

```csharp
// Get OAuth parameters from the query string
string oAuthToken = Request.QueryString["oauth_token"];
string oAuthVerifier = Request.QueryString["oauth_verifier"];

// Grab the request token from the session
SocialOAuthRequestToken requestToken = Session[oAuthToken] as SocialOAuthRequestToken;

// Update the OAuth client with information from the request token
oauth.Token = requestToken.Token;
oauth.TokenSecret = requestToken.TokenSecret;

// Make the request to the Twitter API to get the access token
SocialOAuthAccessTokenResponse response = oauth.GetAccessToken(oAuthVerifier);

// Get the access token from the response body
SocialOAuthAccessToken accessToken = response.Body;

// Update the OAuth client with the access token (we no longer need the request token)
oauth.Token = accessToken.Token;
oauth.TokenSecret = accessToken.TokenSecret;
```

On the last two lines, the OAuth client is updated with the access token and access token secret of the user, which means you're now able to make calls to the Twitter API on behalf of the user.

If you at a later time need to make further requests to the API on behalf of this user, you can store the access token and access token - eg. in the user session on the server, or somewhere in a database. Just keep in mind that the access token and access token secret is sensitive data, and you therefore only be saved in a secure manner.



## Authentication denied

When the user is redirected to the Twitter authentication page, the user may choose to cancel the the authentication, refusing to grant your app access to the user's account. In this case, the user is redirected back to the `Callback` URL, but this time with the `denied` parameter in the query string. This parameter will hold the request token obtained in the first step. You can use the request token to clear the user's session on your server.



## Complete example

In the example below, I've tried to demonstrate how an authentication page can be implemented (involving the steps explained above).

```csharp
@using Skybrud.Social.OAuth.Objects
@using Skybrud.Social.OAuth.Responses
@using Skybrud.Social.Twitter.OAuth

@{

    // Initialize the OAuth client
    TwitterOAuthClient oauth = new TwitterOAuthClient {
        ConsumerKey = "Insert your consumer key here",
        ConsumerSecret = "Insert your consumer secret here",
        Callback = "http://social.abjerner/twitter/oauth/"
    };

    if (Request.QueryString["do"] == "login") {

        // Make the request to the Twitter API to get a request token
        SocialOAuthRequestTokenResponse response = oauth.GetRequestToken();

        // Get the request token from the response body
        SocialOAuthRequestToken requestToken = response.Body;

        // Save the token information to the session so we can grab it later
        Session[requestToken.Token] = requestToken;

        // Redirect the user to the authentication page at Twitter.com
        Response.Redirect(requestToken.AuthorizeUrl);

    } else if (Request.QueryString["oauth_token"] != null) {

        // Get OAuth parameters from the query string
        string oAuthToken = Request.QueryString["oauth_token"];
        string oAuthVerifier = Request.QueryString["oauth_verifier"];

        // Grab the request token from the session
        SocialOAuthRequestToken requestToken = Session[oAuthToken] as SocialOAuthRequestToken;

        if (requestToken == null) {

            <p>An error occured. Timeout?</p>

        } else {

            // Some information for development purposes
            <p>Request Token: @requestToken.Token</p>
            <p>Request Token Secret: @requestToken.TokenSecret</p>

            // Update the OAuth client with information from the request token
            oauth.Token = requestToken.Token;
            oauth.TokenSecret = requestToken.TokenSecret;

            try {

                // Make the request to the Twitter API to get the access token
                SocialOAuthAccessTokenResponse response = oauth.GetAccessToken(oAuthVerifier);

                // Get the access token from the response body
                SocialOAuthAccessToken accessToken = response.Body;

                <p>Access Token: @accessToken.Token</p>
                <p>Access Token Secret: @accessToken.TokenSecret</p>

                // Update the OAuth client with information from the access token
                oauth.Token = accessToken.Token;
                oauth.TokenSecret = accessToken.TokenSecret;

            } catch (Exception ex) {

                <pre style="color: red;">@ex.GetType().FullName: @(ex.Message + "\r\n\r\n" + ex.StackTrace)</pre>

            }


        }

    } else if (Request.QueryString["denied"] != null) {

        // Get OAuth parameters from the query string
        string oAuthToken = Request.QueryString["denied"];

        // Remove the request token from the session
        Session.Remove(oAuthToken);

        // Write some output for the user
        <p>It seems that you cancelled the login!</p>
        <p>
            <a class="btn btn-primary" href="/twitter/oauth/?do=login">Try again?</a>
        </p>

    } else {

        <p>
            <a class="btn btn-primary" href="/twitter/oauth/?do=login">Login with Twitter</a>
        </p>

    }

}
```