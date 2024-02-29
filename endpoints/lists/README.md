# Lists

The **Lists** endpoint let's you create and manage lists of Twitter users.



## Getting details about a single list

Using the `GetList` method, you can request the details about a specific list. For instance `956229313061367809` as shown in the example below, is the ID of my example list.

```cshtml
@using Skybrud.Social.Twitter.Models.Lists
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the Twitter API
    TwitterListResponse response = Model.Lists.GetList(956229313061367809);

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}
```



## Getting the list of the authenticated user

In a similar way, you can use the `GetLists` method to get the lists of the authenticated user:

```cshtml
@using Skybrud.Social.Twitter.Models.Lists
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the Twitter API
    TwitterListsResponse response = Model.Lists.GetLists();

    // Iterate through the lists
    foreach (TwitterList list in response.Body) {

        <pre>@list.Id => @list.Name</pre>

    }

}
```



## Creating a new list

Also, you can use the `CreateList` method to create a new list. The Twitter API will then respond with the details about the new list:

```cshtml
@using Skybrud.Social.Twitter.Models.Lists
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the Twitter API
    TwitterCreateListResponse response = Model.Lists.CreateList("Hest");

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}
```



## Deleting a list

If you no longer need one of your lists, you can use the `DeleteList` method for deleting that particular list. Even though the request will delete the list, the Twitter will like the examples above still return the details about the list.

```cshtml
@using Skybrud.Social.Twitter.Models.Lists
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the Twitter API
    TwitterDeleteListResponse response = Model.Lists.DeleteList(956229313061367809);

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}
```



## Adding a member to a list

Either by the ID of the user (the first parameter is the ID of the list, while the second parameter the is ID of the user):

```cshtml
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the API
    TwitterAddMemberResponse response = Model.Lists.AddMember(956229313061367809, 319219802);

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}
```

or by the screen name of the user:


```cshtml
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the API
    TwitterAddMemberResponse response = Model.Lists.AddMember(956229313061367809, "abjerner");

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}
```



## Removing a member from a list

Similar to adding a new member, you can also remove a member from the list (the first parameter is the ID of the list, while the second parameter the is ID of the user):

```cshtml
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the API
    TwitterRemoveMemberResponse response = Model.Lists.RemoveMember(956229313061367809, 319219802);

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}
```

or by the screen name:

```cshtml
@using Skybrud.Social.Twitter.Responses.Lists
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the request to the API
    TwitterRemoveMemberResponse response = Model.Lists.RemoveMember(956229313061367809, "abjerner");

    // Get the list details from the response body
    TwitterList body = response.Body;

    <pre>@body.Name</pre>
    <pre>@body.Description</pre>
    <pre>@body.SubscriberCount</pre>
    <pre>@body.MemberCount</pre>

}```