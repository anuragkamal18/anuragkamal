
Displaybtn = React.createClass({
    getInitialState: function() {
        return {
            //value: 'select'
        }
    },
    displayValueClick: function () {
        let bandAVal;
        
        $.ajax({
            url: 'OhmValue/GetOhmValue',
            dataType:'json',
            data:{'bandAValue':this.state.selectBandAValue},
            cache: false,
            success: function(data){
                this.setState({data}, function(){
                    console.log(this.state);
                });
            }.bind(this),
            error: function(xhr, status, err){
                console.log(err);
            }
        });
    },
    render: function() {
        return (
              <div class="row col-md-12">
                  <button onClick={this.displayValueClick}>
                   Display Value
                </button>
              </div>
    );
    }
});

//React.render(
//<Displaybtn/>, document.getElementById('displayBtn')
//);