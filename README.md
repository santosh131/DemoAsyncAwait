# DemoAsyncAwait
Demo Async await .net core  webapi project 

## Project does not have any UI , so please se the swagger to look at api end points

## Task.ConfigureAwait
When an asynchronous method awaits a Task directly, continuation usually occurs in the same thread 
that created the task, depending on the async context. This behavior can be costly in terms of 
performance and can result in a deadlock on the UI thread.
To avoid these problems, call Task.ConfigureAwait(false)

## Never return Void for async/await, instead return Task

## Added .editorconfig -open with notepad (see the file_header_template setting - Add the header for each file) 

# Configured swagger
# Used ProducesResponseType in the controller