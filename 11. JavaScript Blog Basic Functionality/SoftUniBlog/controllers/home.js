const mongoose = require('mongoose');
const Article = mongoose.model('Article');

module.exports = {
  index: (req, res) => {
      Article.find({}).limit(6).populate('author').then(articles =>{
          articles.forEach(x => {x.content = x.content.substring(0, 500)});
          res.render('home/index', {articles: articles});
      })
  }
};