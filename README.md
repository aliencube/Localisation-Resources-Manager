# Localisation Resource Manager #

Localisation Resource Manager (LRM) converts configuration section from web.config or app.config for localisation resources to objects to be directly used within applications.


# Basic Concepts #

There are thousands of approaches to manage localisation resources. **LRM** can be one of them. However, this provides a bit convenient way to manage localisation resources for both application administrators and developers.

**LRM** basically converts .NET resource files (`.resx`) to more readable XML format.

For application developers, simply create `Resource.[locale].resx` files and enter the localisation messages as many as you want and **LRM** will convert all `.resx` files created to locale specific XML files.

For application administrators, simply modify existing XML files and **LRM** will be automatically applied to your applications.


# Documentation #

Please refer to the [wiki](https://github.com/aliencube/Localisation-Resources-Manager/wiki) page.


# License #

**LRM** is released under [MIT License](http://opensource.org/licenses/MIT).

> The MIT License (MIT)
> 
> Copyright (c) 2013 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
