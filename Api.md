**Content**
- [Program details - rfc specification](#program-details---rfc-specification)
    - [Members of a Problem Details Object](#members-of-a-problem-details-object)
- [Auth](#auth)
    - [Register](#register)
        - [Register request](#register-request)
        - [Register response](#register-response)
    - [Login](#login)
        - [Login request](#login-request)
        - [Login response](#login-response)

## Program details - rfc specification

HTTP status codes (Section 15 of [HTTP]) cannot always convey enough information about errors to be helpful. While humans using web browsers can often understand an HTML [HTML5] response content, non-human consumers of HTTP APIs have difficulty doing so.To address that shortcoming, this specification defines simple JSON [JSON] and XML [XML] document formats to describe the specifics of a problem encountered -- "problem details".
[More...](https://www.rfc-editor.org/rfc/rfc9457.html)
[Statuses...](https://datatracker.ietf.org/doc/html/rfc7231)

The canonical model for problem details is a JSON [JSON] object. When serialized in a JSON document, that format is identified with the "application/problem+json" media type.

For example:
``` json
POST /purchase HTTP/1.1
Host: store.example.com
Content-Type: application/json
Accept: application/json, application/problem+json

{
  "item": 123456,
  "quantity": 2
}
```
``` json
HTTP/1.1 403 Forbidden
Content-Type: application/problem+json
Content-Language: en

{
 "type": "https://example.com/probs/out-of-credit",
 "title": "You do not have enough credit.",
 "detail": "Your current balance is 30, but that costs 50.",
 "instance": "/account/12345/msgs/abc",
 "balance": 30,
 "accounts": ["/account/12345",
              "/account/67890"]
}
```
Here, the out-of-credit problem (identified by its type) indicates the reason for the 403 in "title", identifies the specific problem occurrence with "instance", gives occurrence-specific details in "detail", and adds two extensions: "balance" conveys the account's balance, and "accounts" lists links where the account can be topped up.

### Members of a Problem Details Object
Problem detail objects can have the following members. If a member's value type does not match the specified type, the member MUST be ignored -- i.e., processing will continue as if the member had not been present.

[Type](https://www.rfc-editor.org/rfc/rfc9457.html#name-type), [Status](https://www.rfc-editor.org/rfc/rfc9457.html#name-status), [Title](https://www.rfc-editor.org/rfc/rfc9457.html#name-title), [Detail](https://www.rfc-editor.org/rfc/rfc9457.html#name-detail), [Instance](https://www.rfc-editor.org/rfc/rfc9457.html#name-instance)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register request
``` json
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@gmail.com",
    "password": "pwd123"
}
```

#### Register response
``` js
200 OK
```

``` json
{
    "id": "d54g3f5h-eg4s-95ll-b539d24gh245",
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@gmail.com",
    "token": "werwff..werwer3"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login request
``` json
{
    "email": "john.doe@gmail.com",
    "password": "pwd123"
}
```

#### Login response
``` js
200 OK
```

``` json
{
    "id": "d54g3f5h-eg4s-95ll-b539d24gh245",
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@gmail.com",
    "token": "werwff..werwer3"
}
```