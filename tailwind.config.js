module.exports = {
    theme: {
        extend: {
            spacing: {
                '72': "18rem",
                '80': "20rem",
            },
            padding: {
                '5/6': "83.3333333%"
            }
        },
        customForms: theme => ({
            default: {
                'input, textarea': {
                    borderColor: "transparent",
                    lineHeight: theme("lineHeight.snug"),
                    borderRadius: theme("borderRadius.lg"),
                    backgroundColor: theme("colors.gray.700"),
                    '&:focus': {
                        boxShadow: "none",
                        borderColor: "transparent"
                    }
                },
                'select, multiselect': {
                    borderColor: "transparent",
                    lineHeight: theme("lineHeight.snug"),
                    borderRadius: theme("borderRadius.lg"),
                    backgroundColor: theme("colors.gray.700"),
                    '&:focus': {
                        boxShadow: "none",
                        borderColor: "transparent"
                    },
                    icon: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="#fff"><path d="M15.3 9.3a1 1 0 0 1 1.4 1.4l-4 4a1 1 0 0 1-1.4 0l-4-4a1 1 0 0 1 1.4-1.4l3.3 3.29 3.3-3.3z"/></svg>`
                },
                checkbox: {
                    borderColor: "transparent",
                    borderRadius: theme("borderRadius.lg"),
                    backgroundColor: theme("colors.gray.700"),
                    '&:focus': {
                        boxShadow: "none",
                        borderColor: "transparent"
                    },
                    height: "1.5em",
                    width: "1.5em",
                    '&:checked': {
                        borderColor: theme("colors.indigo.500"),
                        backgroundColor: theme("colors.indigo.500")
                    }
                },
                radio: {
                    borderColor: "transparent",
                    borderRadius: theme("borderRadius.lg"),
                    backgroundColor: theme("colors.gray.700"),
                    '&:focus': {
                        boxShadow: "none",
                        borderColor: "transparent"
                    },
                    height: "1.5em",
                    width: "1.5em",
                    '&:checked': {
                        borderColor: theme("colors.indigo.500"),
                        backgroundColor: theme("colors.indigo.500")
                    }
                }
            }
        })
    },
    variants: {},
    plugins: [
        require("@tailwindcss/custom-forms")
    ]
}
