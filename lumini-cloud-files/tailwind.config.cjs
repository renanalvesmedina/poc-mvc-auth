/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.tsx"],
  theme: {
    extend: {
      fontFamily: {
        'sans': ['Roboto']
      },
      colors: {
        brand: {
          400: '#5BB8D9',
          500: '#1B93B5',
        },
        back: {
          100: '#FBFAFC',
          800: '#18181B',
          900: '#09090A'
        }
      }
    },
  },
  plugins: [
    require('tailwind-scrollbar-hide')
  ],
}
