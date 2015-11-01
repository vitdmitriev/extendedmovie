var express = require('express');
var router = express.Router();
var api = require('../internal/api');
var unirest = require('unirest');
var fs = require("fs");
var multiparty = require('multiparty');
var restler = require('restler');
var qr = require('qr-image');

var BASE_URI = 'http://movie-extended.azurewebsites.net/api';

router.get('/', function(req, res) {
    res.end('Works!');
});

router.get('/companies', function(req, res) {
    res.writeHead({'Content-Type': 'application/json'});
    res.end(JSON.stringify([{
        Id: 1,
        Name: 'Каро фильм',
        Website: 'http://test.ru',
        PhotoUri: 'https://www.npmjs.com/static/images/npm-logo.svg'
    }, {
        Id: 2,
        Name: 'Пять звезд',
        Website: 'http://test2.com',
        PhotoUri: 'https://www.npmjs.com/static/images/npm-logo.svg'
    }]));
});

router.post('/companies', function(req, res) {
    var data = req.body;
    api.Companies('post', data, function (err, result) {
        res.end(result);
    });
});

router.get('/companies/:id', function(req, res) {
    var data = {
        company_guid: req.params.id
    };
    api.Companies('get', data, function (err, result) {
        res.writeHead({'Content-Type': 'application/json'});
        res.end(JSON.stringify(result));
    });
});

router.post('/companies/:company_id/cinemas', function(req, res) {
    var data = {
        company_guid: req.params.company_id,
        data: req.body
    };
    api.Cinemas('post', data, function (err, result) {
        res.writeHead({'Content-Type': 'application/json'});
        res.end(result);
    });
});

router.get('/companies/:company_id/cinemas', function(req, res) {
    var data = {
        company_guid: req.params.company_id
    };
    api.Cinemas('get', data, function (err, result) {
        res.writeHead({'Content-Type': 'application/json'});
        res.end(JSON.stringify(result));
    });
});

router.get('/companies/:company_id/cinemas/:cinema_id', function(req, res) {
    var companyId = req.params.company_id,
        cinemaId = req.params.cinema_id;

    var apiUrl = BASE_URI + '/Companies/' + companyId + '/Cinemas/' + cinemaId;
    unirest.get(apiUrl)
        .end(function (response) {
            var bodyResponse = response.body;
            if (!bodyResponse) {
                return res.end();
            }
            res.writeHead({'Content-Type': 'application/json'});
            res.end(JSON.stringify(bodyResponse));
        });
});

router.get('/cinemas/:cinema_id/movies', function(req, res) {
    var cinemaId = req.params.cinema_id;

    var apiUrl = BASE_URI + '/Cinemas/' + cinemaId + '/Movies';
    unirest.get(apiUrl)
        .end(function(response) {
            var bodyResponse = response.body;
            if (!bodyResponse) {
                return res.end();
            }
            if (Array.isArray(bodyResponse)) {
                for (var el in bodyResponse) {
                    bodyResponse[el].QR = getQR(bodyResponse[el].Id);
                }
            }
            res.writeHead({'Content-Type': 'application/json'});
            res.end(JSON.stringify(bodyResponse));
        });
});

router.get('/cinemas/:cinema_id/movies/:movie_id', function(req, res) {
    var cinemaId = req.params.cinema_id;
    var movieId = req.params.movie_id;

    var apiUrl = BASE_URI + '/Cinemas/' + cinemaId + '/Movies/' + movieId;
    unirest.get(apiUrl)
        .end(function (response) {
            var bodyResponse = response.body;
            if (!bodyResponse) {
                return res.end();
            }
            res.writeHead({'Content-Type': 'application/json'});
            res.end(JSON.stringify(bodyResponse));
        });
});

router.post('/cinemas/:cinema_id/movies', function(req, res) {
    var cinemaId = req.params.cinema_id;
    var apiUrl = BASE_URI + '/Cinemas/' + cinemaId + '/Movies';

    unirest.post(apiUrl)
        .headers({'Content-Type': 'application/json'})
        .send(req.body)
        .end(function (response) {
            var bodyResponse = response.body;
            if (!bodyResponse) {
                return res.end();
            }
            res.end(bodyResponse);
        });
});

router.delete('/cinemas/:cinema_id', function(req, res) {
    res.end('Not implemented');
});

router.get('/movies/:movie_id/tracklanguages', function (req, res) {
    var movieId = req.params.movie_id.trim(),
        apiUrl = BASE_URI + '/Movies/' + movieId + '/TrackLanguages';

    unirest.get(apiUrl)
        .end(function (response) {
            var bodyResponse = response.body;
            if (!bodyResponse) {
                return res.end();
            }
            res.writeHead({'Content-Type': 'application/json'});
            res.end(JSON.stringify(bodyResponse));
        });
});

router.post('/movies/:movie_id/tracklanguages', function (req, res) {
    var movieId = req.params.movie_id;
    var apiUrl = BASE_URI + '/Movies/' + movieId + '/TrackLanguages';

    unirest.post(apiUrl)
        .headers({'Content-Type': 'application/json'})
        .send(req.body)
        .end(function (response) {
            var bodyResponse = response.body;
            if (!bodyResponse) {
                return res.end();
            }
            res.end(bodyResponse);
        });
});

router.get('/movies/:movie_id/tracklanguages/:language_id', function (req, res) {
    var movieId = req.params.movie_id,
        languageId = req.params.language_id;

    res.writeHead({'Content-Type': 'application/json'});
    res.end(JSON.stringify({
        Id: 34534,
        Name: 'Английский'
    }));
});

router.delete('/tracklanguages/:language_id', function(req, res) {
    var languageId = req.params.language_id;
    res.end();
});

router.post('/files', function (req, res) {
    setTimeout(function () {
        res.end('2d62b71b-9450-4391-abc9-0601a13e0147');
    }, 3000);
});

function getQR(guid) {
    return qr.imageSync(guid, { type: 'svg' });
}

module.exports = router;