package app.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.io.File;

@Controller
public class FilesController {
    @RequestMapping("/files")
    public String files(@RequestParam(value = "pathString", defaultValue = "C:\\") String pathString, Model model) {
        //System.out.println(pathString);
        File path = new File(pathString);
        File[] allFiles = path.listFiles();
        model.addAttribute("allFiles", allFiles);
        return "files";
    }
}
