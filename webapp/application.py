from flask import Flask, render_template
# set the project root directory as the static folder, you can set others.
app = Flask(__name__, static_url_path='')

@app.route("/test")
def test():
    return "test test test"

@app.route("/")
def intro():
    return render_template('intro.html')

@app.route("/challenge")
def game():
    return render_template('game.html')


@app.route("/droid")
def droid():
    return render_template('droid.html')


if __name__ == "__main__":
    app.run(debug=True)