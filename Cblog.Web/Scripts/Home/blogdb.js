angular.module('blogdb', ['ngResource'])
    .factory('BlogDb', function ($resource) {
        var BlogDb = $resource('/api/Blog/:id', {},
            {
                query: { method: 'GET', isArray: true },
                get: { method: 'GET' }
            }
        );

        return BlogDb;
    });