# Twitter

Accessing or posting data to the Twitter API requires your to specify either an app context or a user context. You can read more about this at the [authentication page](./authentication/).

When you have gained access to the API, Twitter limits/throttles your access, meaning that certain endpoints or methods only can be called a certain amount of times for a given period. You can read more about this on the page about [rate limiting](./rate-limiting/).



## Installation

{{installation}}



## Structure

Like most of the other supported APIs and services, the Twitter API itself is divided into multiple endpoints, each serving a different purpose or kind of data. For instance there is a [statuses endpoint](./endpoints/statuses/) for working with status messages and a [users endpoint](./endpoints/users/) for working with users.

The Skybrud.Social implementation tries to follow the structure of the API, but also doesn't support the entire API. You can see the supported endpoints via the list below:

{{endpoints}}



## Making calls to the API

When using Skybrud.Social to access the the Twitter API, there are two main classes that you should know about.

Twitter uses OAuth 1.0a for authentication and authorization of each request sent to the API. OAuth 1.0a involves a lot of security, but you don't really need to know a lot about this, since it is handled by the `TwitterOAuthClient` class. This class will handle authentication as well as the raw communication with the API (and the security involved for each request).

Calls to the API using the `TwitterOAuthClient` class will return an instance of the `SocialHttpResponse`, where the `Body` property represents to raw JSON body returned by the API.

The other class you need to know about is the `TwitterService` class. This class builds on top of `TwitterOAuthClient`, and calls to the API using this class will result in strongly typed classes representing the JSON returned by the API.

Since `TwitterService` builds on top of `TwitterOAuthClient`, you first need to create a new instance of `TwitterOAuthClient`. If you don't need to access the API as a specific user, you can initialize the class as:

```csharp
// Initialize a new OAuth client from the consumer key and secret
TwitterOAuthClient client = new TwitterOAuthClient {
    ConsumerKey = "your consumer/app key",
    ConsumerSecret = "your consumer/app secret"
};
```

To access the API as a specific user, you should also specify the access token and access token secret (read more about [authentication](./authentication/)) of the user:

```csharp
// Initialize a new OAuth client from the consumer key and secret
TwitterOAuthClient client = new TwitterOAuthClient {
    ConsumerKey = "your consumer/app key",
    ConsumerSecret = "your consumer/app secret",
    Token = "access token of the user",
    TokenSecret = "access token secret of the user"
};
```

Once you have an instance of the `TwitterOAuthClient` class, you can use it to create an instance of the `TwitterService` class like:

```csharp
// Initialize a new service instance from the OAuth client
TwitterService service = TwitterService.CreateFromOAuthClient(client);
```