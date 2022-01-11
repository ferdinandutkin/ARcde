const attach_handler = form => {
    let mark_select = form.Mark;
    let model_select = form.Model;


    const set_model_select_options_by_mark = mark => {
        const clear_model_select = () => {
            while (model_select.length > 0) {
                model_select.remove(0);
            }
        }

        clear_model_select();

        fetch(`models/${mark}`)
            .then(resp => resp.json())
            .then(models => {
                models.forEach(model => {
                    model_select.appendChild(new Option(model, model));
                });

            });
    }

    const mark_select_update_handler = e => {
        set_model_select_options_by_mark(e.target.value);
    }


    set_model_select_options_by_mark(mark_select.value);
    mark_select.addEventListener("change", mark_select_update_handler);


}