package com.softuni.controller;

import com.softuni.entity.Calculator;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
    @ModelAttribute("calc")
    public Calculator getCalc(){
        return new Calculator();
    }

	@GetMapping("/")
	public String index(Model model) {
		model.addAttribute("operator", "+");
		model.addAttribute("view", "views/calculatorForm");
		return "base-layout";
	}

    @PostMapping("/")
    public String calculate(@ModelAttribute("calc") Calculator calculator,
                            Model model){

        double result = calculator.calculateResult();

        model.addAttribute("leftOperand", calculator.getLeftOperand());
        model.addAttribute("operator", calculator.getOperator());
        model.addAttribute("rightOperand", calculator.getRightOperand());
        model.addAttribute("result", result);

        model.addAttribute("view","views/calculatorForm");

        return "base-layout";
    }
}
