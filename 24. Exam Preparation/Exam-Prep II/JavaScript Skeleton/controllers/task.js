const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
        /*let tasksPromises = [Task.find({status: "Open"}),
            Task.find({status: "In Progress"}),
            Task.find({status: "Finished"})];

	    Promise.all(tasksPromises).then(taskResults => {
        	res.render('task/index', {'openTasks': taskResults[0],
                'inProgressTasks': taskResults[1],
                'finishedTasks': taskResults[2]});
        });*/

        Task.find().then(tasks => {
            res.render('task/index', {
                'openTasks': tasks.filter(t => t.status === "Open"),
                'inProgressTasks': tasks.filter(t => t.status === "In Progress"),
                'finishedTasks': tasks.filter(t => t.status === "Finished"),
            });
        });
	},
	createGet: (req, res) => {
        res.render('task/create');
	},
	createPost: (req, res) => {
        let taskArgs = req.body;

        if(!taskArgs.title || !taskArgs.status){
            res.render('task/create', {error: "Cannot create task!"});
            return;
        }

        Task.create(taskArgs).then(task => {
            res.redirect('/');
        });
	},
	editGet: (req, res) => {
        let id = req.params.id;

        Task.findById(id).then(task => {
            if(!task){
                res.redirect('/');
            } else {
                res.render('task/edit', task);
            }
        }).catch(err => res.redirect('/'));
	},
	editPost: (req, res) => {
        let id = req.params.id;

        Task.findById(id).then(task => {
            if(!task){
                res.redirect('/');
                return;
            }

            if(!req.body.title || !req.body.status){
                res.redirect('/');
                return;
            }

            task.title = req.body.title;
            task.status = req.body.status;

            task.save().then(task => {
                res.redirect('/');
            });
        });
	}
};