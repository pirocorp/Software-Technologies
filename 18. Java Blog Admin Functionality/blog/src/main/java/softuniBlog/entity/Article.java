package softuniBlog.entity;

import javax.persistence.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

@Entity
@Table(name = "articles")
public class Article {

    private Integer id;

    private String title;

    private String content;

    private User author;

    private String imagePath;

    public Article(String title, String content, User author, String imagePath) {
        this.title = title;
        this.content = content;
        this.author = author;
        this.imagePath = imagePath;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false)
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Column(columnDefinition = "text", nullable = false)
    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    @ManyToOne
    @JoinColumn(nullable = false, name = "authorId")
    public User getAuthor() {
        return author;
    }

    public void setAuthor(User author) {
        this.author = author;
    }

    public Article(String title, String content, User author) {
        this.title = title;
        this.content = content;
        this.author = author;
    }

    public Article() {    }

    @Transient
    public String getSummary(){
        Pattern pattern = Pattern.compile(".{50,}?\\s");
        String content = this.getContent();
        Matcher matcher = pattern.matcher(content);
        String summary;

        if(content.length() > 100 && matcher.find()){
            summary = matcher.group(0);
        } else {
            summary = content.substring(0, content.length() / 2);
        }

        return summary;
    }

    public String getImagePath() {
        return imagePath;
    }

    public void setImagePath(String imagePath) {
        this.imagePath = imagePath;
    }
}
