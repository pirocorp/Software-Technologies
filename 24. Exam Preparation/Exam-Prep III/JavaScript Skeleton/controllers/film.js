const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
		Film.find().then(films => {
            res.render('film/index', {'films': films});
		});
	},
	createGet: (req, res) => {
        res.render('film/create');
	},
	createPost: (req, res) => {
        let filmArgs = req.body;

        if(!filmArgs.name || !filmArgs.genre || !filmArgs.director || !filmArgs.year){
            res.redirect('/');
            return;
        }

        Film.create(filmArgs).then(film => {
            res.redirect('/');
        });
	},
	editGet: (req, res) => {
        let id = req.params.id;

        Film.findById(id).then(film => {
            if(!film){
                res.redirect('/');
            } else {
                res.render('film/edit', film);
            }
        }).catch(err => res.redirect('/'));
	},
	editPost: (req, res) => {
        let id = req.params.id;

        Film.findById(id).then(film => {
            if(!film){
                res.redirect('/');
                return;
            }

            if(!req.body.name || !req.body.genre || !req.body.director || !req.body.year){
                res.redirect('/');
                return;
            }

            film.name = req.body.name;
            film.genre = req.body.genre;
            film.director = req.body.director;
            film.year = req.body.year;

            film.save().then(film => {
                res.redirect('/');
            });
        });
	},
	deleteGet: (req, res) => {
        let id = req.params.id;

        Film.findById(id).then(film => {
            if(!film){
                res.redirect('/');
                return;
            }

            res.render('film/delete', film);
        });
	},
	deletePost: (req, res) => {
        let id = req.params.id;

        Film.findByIdAndRemove(id).then(film => {
            res.redirect('/');
        });
	}
};