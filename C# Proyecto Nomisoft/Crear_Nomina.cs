// prevent double subscription when Designer and constructor both wire the event
if (this.Button_Crear != null)
{
    // remove any previous subscriptions the Designer might have added
    this.Button_Crear.Click -= Button_Crear_Click_1;
    this.Button_Crear.Click -= button_Crear_Click;
    // subscribe exactly once
    this.Button_Crear.Click += button_Crear_Click;
}