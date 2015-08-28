/// <reference path="../jasmine.js" />
/// <reference path="../angular.js" />
/// <reference path="../angular-mocks.js" />
/// <reference path="../app/userService.js" />
"use strict";

describe("Api user service", function () {
    var userService, httpBackend;

    beforeEach(module("myApp"));

    beforeEach(inject(function (_userService_, $httpBackend) {
        userService = _userService_;
        httpBackend = $httpBackend;
    }));

    it("should dedupe the results", function () {
        httpBackend.whenGET("http://api.reddit.com/user/yoitsnate/submitted.json").respond({
            data: {
                children: [
                  {
                      data: {
                          subreddit: "golang"
                      }
                  },
                  {
                      data: {
                          subreddit: "javascript"
                      }
                  },
                  {
                      data: {
                          subreddit: "golang"
                      }
                  },
                  {
                      data: {
                          subreddit: "javascript"
                      }
                  }
                ]
            }
        });

        userService.getSubredditsSubmittedToBy("yoitsnate").then(function (subreddits) {
            expect(subreddits).toEqual(["golang", "javascript"]);
        });
        httpBackend.flush();
    });

});