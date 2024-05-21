**Content**
- [Auth](#auth)
    - [Register](#register)
        - [Register request](#register-request)
        - [Register response](#register-response)
    - [Login](#login)
        - [Login request](#login-request)
        - [Login response](#login-response)

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