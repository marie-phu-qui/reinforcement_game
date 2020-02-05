from flask import Flask, render_template
# set the project root directory as the static folder, you can set others.
app = Flask(__name__, static_url_path='')

@app.route("/test")
def test():
    return "test test test"

@app.route("/")
def intro():
    return render_template('index.html')

@app.route("/games")
def games():
    return render_template('games.html')

@app.route("/about")
def about():
    return render_template('about.html')

@app.route("/contact")
def contact():
    return render_template('contact.html')

@app.route("/agent")
def single():
    return render_template('agent.html')

if __name__ == "__main__":
    app.run(debug=True)