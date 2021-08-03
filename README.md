Module 500088 (Software Engineering) 2020 ACW1
==============================================

This repository is the main one for your course work.  The full specification is on the module Canvas site.

You must only modify files in the "Utilities" and "UnitTest" projects.

Your work will be automatically tested periodically after you have pushed it to the repository on GitHub.  If it compiles without error and passes all the tests, it will be automatically deployed to a Microsoft Azure website.  The URL for this will be https://uoh-500088-0X.azurewebsites.net, where X is the number of your team 1-6).

Assuming that your application has built and deployed correctly, you can use a tool such as Postman (https://www.postman.com) to test the lilve web version.  You can make GET requests, passing the data in as x-www-form-urlencoded named variable.  For example, to test the ReversString operation, you can make a GET request to https://uoh-500088-0X.azurewebsites.net/api/ReverseString , with the form variable "data" containing the data in the body of the message.  In addition to the functionality that you and your colleagues have been working on, there are also some integration methods:

  - NthSentence(string data, int n) // returns sentence n from the text
  - NthLine(string data, int lineLength, int n) // returns the n line from text when it is formatted in lines no longer than lineLength
  - JustifiedText(string data, int lineLength) // Returns text split into lines exactly lineLength characters long, padded internally to ensure starting and ending at a neat edge
  - HighlightTopWords(string data, int n) // returns the text but with the most popular n words highlighted

Each individual in your team will be assigned specific functionality to implement.  The required methods are documented on the Canvas site.  You must implement both the functionality assigned to you and sufficient unit tests to demonstrate that they work properly.  Note that as the repository is originally set up, the solution will not compile.  You will need to create dummy methods to make it work before you create the real code.  You should also be aware that some functions may depend on others, which other team members may have been assigned to write.

You must use branching and merging in Git to add functionality.  The repository logs will be examined as part of the assessment, and evidence of your individual contributions (branches, merges and commits) will be considered.
